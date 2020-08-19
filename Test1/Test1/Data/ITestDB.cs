using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Data
{
    public interface ITestDB
    {
        Task<List<DBFMail>> OpenDBF(string path);
        Task<List<DBFMail>> GetEmail(string path, string ID, bool direction);

        Task<List<Person>> GetUsers();
        Task<Person> GetPerson(int ID);
    }
}
