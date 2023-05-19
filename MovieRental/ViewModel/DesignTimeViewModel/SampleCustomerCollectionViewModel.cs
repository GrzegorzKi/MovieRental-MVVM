using MovieRental.Model;
using MovieRental.ViewModel;
using System.Collections.Generic;

namespace MovieRental.DesignTimeViewModel;

public class SampleCustomerCollectionViewModel : CustomerCollectionViewModel {

    // Data generated with https://generatedata.com/generator
    public SampleCustomerCollectionViewModel() : base(new List<Customer>() {
        new Customer(1,"Shelly","Estrada","93117 Evansville","1-871-372-7263"),
        new Customer(2,"Althea","Richardson","92160 Evansville","(575) 618-6840"),
        new Customer(3,"Galena","Kelly","31614 Dover","(722) 267-4538"),
        new Customer(4,"Cade","Casey","74577 Atlanta","1-724-363-8148"),
        new Customer(5,"Candace","Stevenson","99675 Des Moines","1-765-565-2433"),
        new Customer(6,"Lacota","Macdonald","63724 Hartford","1-437-949-1331"),
        new Customer(7,"Elijah","Mcneil","36002 Olathe","1-245-286-2854"),
        new Customer(8,"Kelsey","Watts","25335 Burlington","1-271-128-2267"),
        new Customer(9,"Iola","Williamson","77570 Atlanta","1-886-680-7164"),
        new Customer(10,"Nola","Joyce","76957 Hilo","1-714-644-2452"),
        new Customer(11,"Louis","Strickland","94770 Jacksonville","1-430-859-3268"),
        new Customer(12,"Lamar","Benjamin","82307 Green Bay","1-530-552-9128"),
        new Customer(13,"Audrey","Everett","82411 Lakewood","(548) 188-6377"),
        new Customer(14,"Noah","Klein","73836 Metairie","1-127-947-2433"),
        new Customer(15,"Lucius","Mullen","33489 Naperville","(667) 450-1968")
    }) {}
}
