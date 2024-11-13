using Exam3.Models;
using System;
using System.Linq;
using Exam3.Controllers;
using Exam3.Data.DbGamesTableAdapters;

namespace Exam3.Controllers
{
    public class UsersController
    {
        
        public bool Login(string name, string password)
        {
            try
            {
                using (var a = new usuariosTableAdapter())
                {
                    
                    var b = a.GetByName(name).FirstOrDefault(); 

                    if (b != null) 
                    {
                        User user = new User
                        {
                            nombre_usuario = b["nombre_usuario"].ToString(),
                            contrasena = b["contrasena"].ToString()
                        };

                        EncryptController encryptController = new EncryptController();
                        string decryptedPassword = encryptController.Decrypt(user.contrasena);

                        
                        if (decryptedPassword == password)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false; 
        }
    }
}
