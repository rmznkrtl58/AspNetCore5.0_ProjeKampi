﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message2
    {
        [Key]
        public int MessageId { get; set; }
        public int? ReceiverId { get; set; }
        public int? SenderId { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        //ÇOKA ÇOK İLİŞKİ
        //Alıcı Yazar ve Gönderen yazar
        public Writer SenderUser { get; set; }
        public Writer ReceiverUser { get; set; }

    }
}
