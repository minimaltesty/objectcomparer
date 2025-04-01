using System;
using System.Collections.Generic;
using System.Text;

namespace SIT.Components.ObjectComparer.Documentation.Examples.Example_Configuration {
    
    public class Address {

        int _id;
        public int Id { get { return _id; } set { _id = value; } }

        string _street;
        public string Street { get { return _street; } set { _street = value; } }

        string _zip;
        public string Zip { get { return _zip; } set { _zip = value; } }

        string _city;
        public string City { get { return _city; } set { _city = value; } }

    }

    
    public class Customer {

        int _id;
        public int Id { get { return _id; } set { _id = value; } }

        string _displayname;
        public string Displayname { get { return _displayname; } set { _displayname = value; } }

        string _number;
        public string Number { get { return _number; } set { _number = value; } }

        string _firstname;
        public string Firstname { get { return _firstname; } set { _firstname = value; } }

        string _lastname;
        public string Lastname { get { return _lastname; } set { _lastname = value; } }

        Address _address = new Address();
        public Address Address { get { return _address; } set { _address = value; } }

    }

    
    public class OrderPosition {

        int _id;
        public int Id { get { return _id; } set { _id = value; } }

        int _orderId;
        public int OrderId { get { return _orderId; } set { _orderId = value; } }

        string _number;
        public string Number { get { return _number; } set { _number = value; } }

        int _orderIndex;
        public int OrderIndex { get { return _orderIndex; } set { _orderIndex = value; } }

        string _text;
        public string Text { get { return _text; } set { _text = value; } }

    }

    
    public class Order {

        int _id;
        public int Id { get { return _id; } set { _id = value; } }

        string _number;
        public string Number { get { return _number; } set { _number = value; } }

        Customer _customer = new Customer();
        public Customer Customer { get { return _customer; } set { _customer = value; } }

        List<OrderPosition> _positions = new List<OrderPosition>();
        public List<OrderPosition> Positions { get { return _positions; } set { _positions = value; } }



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

        public static void ModifyOrder(Order order) {
            if (order.Customer == null)
                order.Customer = new Customer();

            order.Customer.Displayname = string.Concat(order.Customer.Displayname, "+++");
            order.Customer.Firstname = string.Concat(order.Customer.Firstname, "+++");
            order.Customer.Lastname = string.Concat(order.Customer.Lastname, "+++");
            order.Customer.Number = string.Concat(order.Customer.Number, "+++");
            if (order.Customer.Address == null)
                order.Customer.Address = new Address();

            order.Customer.Address.City = string.Concat(order.Customer.Address.City, "+++");
            order.Customer.Address.Street = string.Concat(order.Customer.Address.Street, "+++");
            order.Customer.Address.Zip = string.Concat(order.Customer.Address.Zip, "+++");

            if (order.Positions == null)
                order.Positions = new List<OrderPosition>();

            if (order.Positions.Count > 0) {
                order.Positions[0].Number = string.Concat(order.Positions[0].Number, "+++");
                order.Positions[0].OrderIndex++;
                order.Positions[0].Text = string.Concat(order.Positions[0].Text, "+++");

            }
            if (order.Positions.Count > 1)
                order.Positions.RemoveAt(1);

            int maxPosId = 1;
            order.Positions.ForEach(x => maxPosId = x.Id > maxPosId ? x.Id : maxPosId);
            order.Positions.Add(new OrderPosition() {
                Id = ++maxPosId,
                Number = "No" + maxPosId.ToString(),
                OrderId = order.Id,
                OrderIndex = 99,
                Text = "+++"

            });
            order.Number = string.Concat(order.Number, "+++");

        }

        public static Order CreateSampleOrder1() {
            int orderId = 1;
            Order retval = new Order() {
                Id = orderId,
                Customer = new Customer() {
                    Id = 1,
                    Displayname = "Customer1",
                    Firstname = "John",
                    Lastname = "Doe",
                    Number = "C1",
                    Address = new Address() {
                        Id = 1,
                        City = "New York",
                        Zip = "00000",
                        Street = "S1"
                    }

                },
                Number = "No1",
            };
            retval.Positions.Add(new OrderPosition() {
                Id = 1,
                OrderId = orderId,
                Number = "1",
                OrderIndex = 1,
                Text = "Pos1"
            });
            retval.Positions.Add(new OrderPosition() {
                Id = 2,
                OrderId = orderId,
                Number = "2",
                OrderIndex = 2,
                Text = "Pos2"
            });
            retval.Positions.Add(new OrderPosition() {
                Id = 3,
                OrderId = orderId,
                Number = "3",
                OrderIndex = 3,
                Text = "Pos3"
            });
            return retval;

        }

        public static Order CreateSampleOrder2() {
            int orderId = 2;
            Order retval = new Order() {
                Id = orderId,
                Customer = new Customer() {
                    Id = 1,
                    Displayname = "Customer2",
                    Firstname = "FName",
                    Lastname = "LName",
                    Number = "C2",
                    Address = new Address() {
                        Id = 1,
                        City = "Leipzig",
                        Zip = "00001",
                        Street = "S2"
                    }

                },
                Number = "No2",
            };
            retval.Positions.Add(new OrderPosition() {
                Id = 1,
                OrderId = orderId,
                Number = "1",
                OrderIndex = 1,
                Text = "Pos1"
            });
            retval.Positions.Add(new OrderPosition() {
                Id = 2,
                OrderId = orderId,
                Number = "2",
                OrderIndex = 2,
                Text = "Pos2"
            });
            retval.Positions.Add(new OrderPosition() {
                Id = 3,
                OrderId = orderId,
                Number = "3",
                OrderIndex = 3,
                Text = "Pos3"
            });
            return retval;

        }

    }
}
