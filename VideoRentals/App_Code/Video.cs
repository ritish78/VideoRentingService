using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRentals
{
    public class Video
    {
        private int videoID;
        private string title;
        private double length;
        private string category;
        private double rating;

        public Video(int videoID, string title, double length, string category, double rating)
        {
            this.videoID = videoID;
            this.title = title;
            this.length = length;
            this.category = category;
            this.rating = rating;
        }

        public int VideoID { get => videoID; set => videoID = value; }
        public string Title { get => title; set => title = value; }
        public double Length { get => length; set => length = value; }
        public string Category { get => category; set => category = value; }
        public double Rating { get => rating; set => rating = value; }
    }
}