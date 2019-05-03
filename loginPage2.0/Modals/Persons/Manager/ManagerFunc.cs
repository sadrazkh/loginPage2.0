using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginPage2._0.Modals.Persons.Manager
{
    public class ManagerFunc : ManagerModals
    {
        public bool ChangeUserInfo(int PersonIdGet, short? AccessLevel,string FullName,string Email,string PhoneNumber,string UserName, string Password)
        {
            using(var db = new Modals.PersonContext())
            {
                var res =  db.Persons.Where(i => i.PersonId == PersonIdGet).FirstOrDefault();
                if (res == null)
                {
                    return false;
                }
                else
                {
                    try
                    {
                        if(AccessLevel != null)
                            res.AccessLevel = AccessLevel;
                        if (FullName != null)
                            res.FullName = FullName;
                        if (Email != null)
                            res.Email = Email;
                        if (PhoneNumber != null)
                            res.PhoneNumber = PhoneNumber;                  
                        if (UserName != null)
                            res.UserName = UserName;
                        if (Password != null)
                            res.Password = Password;

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        public bool AddNewProduct(string NewProductName)
        {
            try
            {
                using (var db = new Modals.PersonContext())
                {
                    var res = db.Products.Add(new Product { ProductName = NewProductName });
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
