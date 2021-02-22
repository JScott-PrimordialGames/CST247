﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using UserModel = Activity1Part3.Models.UserModel;

namespace HelloWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {

        public List<UserModel> users;

        public UserService()
        {
            this.users = new List<UserModel>
            {
                new UserModel("Thanos", "IAmInevitable"),
                new UserModel("Thor", "IKnewIt"),
                new UserModel("CaptainAmerica", "AvengersAssemble")
            };
        }

        public DTO GetUser(string id)
        {
            int.TryParse(id, out int UserID);

            if (UserID < this.users.Count)
            {
                return new DTO(0, "OK", new List<UserModel> { this.users[UserID] });
            }
            else
            {
                return new DTO(-1, "User Not In List", null);
            }
        }

        public DTO GetAllUsers()
        {
            return new DTO(0, "OK", this.users);
        }


        public string SayHello()
        {
            return "Hello";
        }

        public string GetData(string value)
        {
            return value;
        }

        public CompositeType GetObjectModel(string id)
        {
            return new CompositeType();
        }
    }
}
