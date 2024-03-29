using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace System.Collections.ObjectModel;

// https://stackoverflow.com/a/45364074/11400707
public class SortableObservableCollection<T> : RangeObservableCollection<T> {
    public SortableObservableCollection() { }

    public SortableObservableCollection(IComparer<T> comparer, bool descending = false) : base() {
        Comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        IsDescending = descending;
    }

    public SortableObservableCollection(IEnumerable<T> collection, IComparer<T> comparer, bool descending = false) : base(collection) {
        Comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        IsDescending = descending;

        Sort();
    }

    internal new IComparer<T>? _comparer;
    public new IComparer<T> Comparer {
        get => _comparer ??= Comparer<T>.Default;
        set {
            _comparer = value;
            Sort();
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Comparer)));
        }
    }

    internal bool _isDescending;
    /// <summary>
    /// Gets or sets a value indicating whether the sorting should be descending.
    /// Default value is false.
    /// </summary>
    public bool IsDescending {
        get => _isDescending;
        set {
            if (_isDescending != value) {
                _isDescending = value;
                Sort();
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsDescending)));
            }
        }
    }

    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e) {
        base.OnCollectionChanged(e);
        if (_reordering) {
            return;
        }
        switch (e.Action) {
            case NotifyCollectionChangedAction.Remove:
            case NotifyCollectionChangedAction.Reset:
                return;
        }

        Sort();
    }

    internal bool _reordering;
    public void Sort() { // TODO, concern change index so no need to walk the whole list
        var query = this.Select((item, index) => (Item: item, Index: index));
        query = IsDescending
          ? query.OrderByDescending(tuple => tuple.Item, Comparer)
          : query.OrderBy(tuple => tuple.Item, Comparer);

        var map = query.Select((tuple, index) => (OldIndex: tuple.Index, NewIndex: index))
         .Where(o => o.OldIndex != o.NewIndex);

        using (var enumerator = map.GetEnumerator()) {
            if (enumerator.MoveNext()) {
                _reordering = true;
                Move(enumerator.Current.OldIndex, enumerator.Current.NewIndex);
                _reordering = false;
            }
        }
    }
}
