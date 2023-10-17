using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Politeh.DAL.Model
{

    //Client cliuent = new Client(0,  DateTime.Now);
    public class Client
    {
        public Client() :this(0)
        {
            
        }
        public Client(int Id):this(Id, DateTime.Now)
        {
         
        }
        public Client(int Id, DateTime CreateDate)
            :this(Id, CreateDate, "")
        {
          
        }
        public Client(int Id, DateTime CreateDate, string PathToImag)
        {
            this.Id = Id;
            this.CreateDate = CreateDate;
            this.PathToImage = PathToImag;
        }

        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string FName { get; set; }
        public string SName { get; set; }
        public string LName { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}",
                    FName, SName, LName);
            }
        }
        public string ShortName
        {
            get
            {
                if(!string.IsNullOrWhiteSpace(LName))
                return string.Format("{0} {1}. {2}.",
                    FName, SName[0], LName[0]);
                else
                    return string.Format("{0} {1}.",FName, SName[0]);
            }
        }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Sex { get; set; }
        public DateTime Dob { get; set; }
        public int Age
        {
            get
            {
                return (DateTime.Now.Year - Dob.Year);
            }
        }
        public string PathToImage { get; set; }

        public Address Address { get; set; }
        public Account[] Accounts { get; set; }
    }
}
