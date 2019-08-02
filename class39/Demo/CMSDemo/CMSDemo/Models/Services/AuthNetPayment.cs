using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using CMSDemo.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSDemo.Models.Services
{
    public class AuthNetPayment : IPayment
    {
        public IConfiguration Configuration { get; }

        public AuthNetPayment(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public string Run()
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // define our merchant information
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = Configuration["AUTHNET_LOGIN_ID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = Configuration["AUTH_TRANSACTION_KEY"]
            };

            creditCardType creditCard = new creditCardType
            {
                cardNumber = Configuration["CreditCardNumber"],
                expirationDate = Configuration["ExpirationDate"]
            };

            customerAddressType billingAddress = GetAddress();

            paymentType payment = new paymentType { Item = creditCard };

            transactionRequestType transReqType = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = 123.45m,
                payment = payment,
                billTo = billingAddress
            };

            createTransactionRequest request = new createTransactionRequest
            {
                transactionRequest = transReqType
            };

            var controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();

            if(response == null)
            {
                if(response.messages.resultCode == messageTypeEnum.Ok)
                {
                    return "Success!";
                }
           
            }
            else
            {
                return "NotOK";
            }

            return "NOT OK";

        }


        public customerAddressType GetAddress()
        {
            // get users personal information

            customerAddressType address = new customerAddressType()
            {
                firstName = "Josie",
                lastName = "Cat",
                address = "123 Catnip Lane",
                city = "Cat Mountain",
                zip = "94729"
            };

            return address;

        }
    }
}
