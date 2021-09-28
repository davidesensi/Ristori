using System;
using Firebase.Database;
using Ristori.Models;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database.Query;

namespace Ristori.Services
{
    public class OperatorService
    {
        FirebaseClient client;

        public OperatorService()
        {
            client = new FirebaseClient("https://ristori-1955c-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<bool> IsOperatorExists(string uname)
        {
            var user = (await client.Child("Operators")
                .OnceAsync<Operator>()).FirstOrDefault(o => o.Object.Username == uname);

            return (user != null);
        }

        public async Task<bool> RegisterOperator (string username, string password)
        {
            if( await IsOperatorExists(username) == false)
            {
                await client.Child("Operators")
                    .PostAsync(new Operator()
                    {
                        Username = username,
                        Password = password
                    }) ;
                return true;

            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginOperator(string username, string password)
        {
            var user = (await client.Child("Operators")
                .OnceAsync<Operator>()).Where(o => o.Object.Username == username)
                .Where(o => o.Object.Password == password).FirstOrDefault();

            return (user != null);
        }
    } 
}
