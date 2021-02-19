using IASHandyMan.CrossCutting.EmailModel;
using System;

namespace IASHandyMan.EmailCommunication.Interface
{
    public interface ICommunication
    {
        public Boolean SendEmailRecoverPassword(ConfirmationEmail confirmation);
    }
}
