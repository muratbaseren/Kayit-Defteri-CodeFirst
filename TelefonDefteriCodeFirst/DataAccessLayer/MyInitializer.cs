using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TelefonDefteriCodeFirst.Models;

namespace TelefonDefteriCodeFirst.DataAccessLayer
{
    public class MyInitializer : CreateDatabaseIfNotExists<KayitTakipDBContext>
    {
        protected override void Seed(KayitTakipDBContext db)
        {
            // SiteUsers eklemesi
            db.SiteUsers.Add(new SiteUser()
            {
                Email = "aaa@aaa.com",
                Name = "Murat",
                Surname = "Başeren",
                Username = "muratbaseren",
                Password = "123"
            });

            db.SaveChanges();

            // Customers ekleme..
            for (int i = 0; i < 10; i++)
            {
                db.Customers.Add(new Customer() {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Age = FakeData.NumberData.GetNumber(25, 90),
                    IsMarried = FakeData.BooleanData.GetBoolean()
                });
            }

            db.SaveChanges();



            List<Customer> musteriler = db.Customers.ToList();

            foreach (Customer cust in musteriler)
            {
                // Müşteriye telefon ekleme
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    db.Phones.Add(new Phone()
                    {
                        Number = FakeData.PhoneNumberData.GetPhoneNumber(),
                        CountryCode = FakeData.NumberData.GetNumber(10,99),
                        IsDefault = false,
                        Customer = cust
                    });
                }

                // Müşteriye adres ekleme
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,4); i++)
                {
                    db.Addresses.Add(new Address() {
                        Description = FakeData.PlaceData.GetAddress(),
                        Country = FakeData.PlaceData.GetCountry(),
                        City = FakeData.PlaceData.GetCity(),
                        Customer = cust
                    });
                }
            }

            db.SaveChanges();

        }
    }
}