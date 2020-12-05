using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRentals
{
    public class User
    {
        private int userID;
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private Boolean isAdmin;
        private Boolean isMember;
        private int noOfRentedVideos;
        private double overdueFees;

        public int UserID { get => userID; set => userID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public bool IsMember { get => isMember; set => isMember = value; }
        public int NoOfRentedVideos { get => noOfRentedVideos; set => noOfRentedVideos = value; }
        public double OverdueFees { get => overdueFees; set => overdueFees = value; }

        public User(int userID, string firstName, string lastName, string email, string phoneNumber, Boolean isAdmin, Boolean isMember, int noOfRentedVideos, double overdueFees)
        {
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.isAdmin = isAdmin;
            this.isMember = isMember;
            this.noOfRentedVideos = noOfRentedVideos;
            this.overdueFees = overdueFees;
        }


    }
}