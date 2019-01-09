using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace THE_MBURUS_FARM.DBL.Models
{
    public class Common
    {

    }
    public class THE_MBURUS_FARMQR
    {
        [Required()]
        public int mnauricode { get; set; }
        [Required()]
        public string bussinessName { get; set; }
        [Required()]
        public string paybill { get; set; }
        [Required()]
        public int qrStatus { get; set; }
    }
    public class Pig
    {
        [Required()]
        public int pigcode { get; set; }
        [Required()]
        public string pigName { get; set; }
        [Required()]
        public string pigBreed { get; set; }
        [Required()]
        public int age { get; set; }
    }
    public class PigBreed
    {
        [Required()]
        public int breedCode { get; set; }
        [Required()]
        public string pigBreed { get; set; }
        [Required()]
        public int total { get; set; }
        [Required()]
        public int data1 { get; set; }
        [Required()]
        public int Descr { get; set; }        
    }
    public class makepigOrder
    {
        [Required()]
        public string breed { get; set; }
        [Required()]
        public int males  { get; set; }
        [Required()]
        public int females { get; set; }
        [Required()]
        public int age { get; set; }
    }

}
