using crm.Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Models.session
{
    public abstract class BaseSession
    {
        public async Task<bool> CheckToken(string token)
        {
            bool res = false;

            try
            {
                await Task.Run(async () => {

                    res = true;

                });
            }
            catch (Exception ex)
            {

            }

            return res;
        }

        public async Task<bool> RegisterUser(string token, BaseUser user)
        {
            bool res = false;

            try
            {
                await Task.Run(async () => {

                    res = true;

                });
            }
            catch (Exception ex)
            {

            }

            return res;
        }

        public async Task<BaseUser> Login(string login, string password)
        {
            User user = new User();

            try
            {
                await Task.Run(async () => {



                });
            }
            catch (Exception ex)
            {

            }

            return user;
        }
    }
}
