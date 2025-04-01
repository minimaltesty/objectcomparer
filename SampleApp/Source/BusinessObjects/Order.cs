using System.Collections.Generic;
using SIT.Components.ObjectComparer;
using SIT.Components.ObjectComparer.Generic;
using System;

namespace SampleApp.Source.BusinessObjects {

    [CompareClass("Address","Id")]
    public class Address{

        int _id;
        public int Id { get { return _id; } set { _id=value; } }

        string _street;
        public string Street{get{return _street;}set{_street=value;}}

        string _zip;
        public string Zip{get{return _zip;}set{_zip=value;}}

        string _city;
        public string City{get{return _city;}set{_city=value;}}

    }

    [CompareClass( "Customer", "Id" )]
    public class Customer{

        int _id;
        public int Id { get { return _id; } set { _id=value; } }

        string _displayname;
        public string Displayname{get{return _displayname;}set{_displayname=value;}}

        string _number;
        public string Number{get{return _number;}set{_number=value;}}

        string _firstname;
        public string Firstname{get{return _firstname;}set{_firstname=value;}}

        string _lastname;
        public string Lastname{get{return _lastname;}set{_lastname=value;}}

        Address _address=new Address();
        public Address Address{get{return _address;}set{_address=value;}}

    }

    [CompareClass( "OrderPosition", "Id" )]
    public class OrderPosition {

        int _id;
        public int Id { get { return _id; } set { _id=value; } }

        int _orderId;
        public int OrderId { get { return _orderId; } set { _orderId=value; } }

        string _number;
        public string Number { get { return _number; } set { _number=value; } }

        int _orderIndex;
        public int OrderIndex { get { return _orderIndex; } set { _orderIndex=value; } }

        string _text;
        public string Text { get { return _text; } set { _text=value; } }

    }

    [CompareClass( "Order", "Id" )]
    public class Order : DeepCopyBase<Order>, ICloneable 
    {

        int _id;
        public int Id { get { return _id; } set { _id=value; } }

        string _number;
        public string Number { get { return _number; } set { _number=value; } }

        Customer _customer=new Customer();
        public Customer Customer { get { return _customer; } set { _customer=value; } }

        List<OrderPosition> _positions=new List<OrderPosition>();
        public List<OrderPosition> Positions { get { return _positions; } set { _positions=value; } }



        #region ICloneable Members

        public object Clone() {
            return new Order() {
                _customer = this._customer,
                _number = this._number,
                _id = this._id,
                _positions = this._positions
            };
        }



        #endregion
    }

    public class SampleData {

        public static Order CreateSampleOrder1() {
            int orderId = 1;
            Order retval=new Order() {
                Id=orderId,
                Customer=new Customer() {
                    Id=1,
                    Displayname="Customer1",
                    Firstname="Alexander",
                    Lastname="Loesel",
                    Number="C1",
                    Address=new Address() {
                        Id=1,
                        City="Dresden",
                        Zip="00000",
                        Street="S1"
                    }

                },
                Number="No1",
            };
            retval.Positions.Add( new OrderPosition() {
                Id=1,
                OrderId=orderId,
                Number="1",
                OrderIndex=1,
                Text="Pos1"
            } );
            retval.Positions.Add( new OrderPosition() {
                Id=2,
                OrderId=orderId,
                Number="2",
                OrderIndex=2,
                Text="Pos2"
            } );
            retval.Positions.Add( new OrderPosition() {
                Id=3,
                OrderId=orderId,
                Number="3",
                OrderIndex=3,
                Text="Pos3"
            } );
            return retval;

        }

        public static Order CreateSampleOrder2() {
            int orderId=2;
            Order retval=new Order() {
                Id=orderId,
                Customer=new Customer() {
                    Id=1,
                    Displayname="Customer2",
                    Firstname="FName",
                    Lastname="LName",
                    Number="C2",
                    Address=new Address() {
                        Id=1,
                        City="Leipzig",
                        Zip="00001",
                        Street="S2"
                    }

                },
                Number="No2",
            };
            retval.Positions.Add( new OrderPosition() {
                Id=1,
                OrderId=orderId,
                Number="1",
                OrderIndex=1,
                Text="Pos1"
            } );
            retval.Positions.Add( new OrderPosition() {
                Id=2,
                OrderId=orderId,
                Number="2",
                OrderIndex=2,
                Text="Pos2"
            } );
            retval.Positions.Add( new OrderPosition() {
                Id=3,
                OrderId=orderId,
                Number="3",
                OrderIndex=3,
                Text="Pos3"
            } );
            return retval;

        }

    }

}
