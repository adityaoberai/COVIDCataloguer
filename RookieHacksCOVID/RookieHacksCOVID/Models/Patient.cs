using System;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RookieHacksCOVID.Models
{
    public class Patient : INotifyPropertyChanged
    {
        long _id;
        [BsonElement("Id")]
        public long Id
        {
            get => _id; set
            {
                if (_id == value)
                    return;

                _id = value;

                HandlePropertyChanged();
            }
        }

        string _name;
        [BsonElement("Name")]
        public string Name
        {
            get => _name; set
            {
                if (_name == value)
                    return;

                _name = value;

                HandlePropertyChanged();
            }
        }

        string _email;
        [BsonElement("Email")]
        public string Email
        {
            get => _email;
            set
            {
                if (_email == value)
                    return;

                _email = value;

                HandlePropertyChanged();
            }
        }

        string _cstatus;
        [BsonElement("CStatus")]
        public string CStatus
        {
            get => _cstatus;
            set
            {
                if (_cstatus == value)
                    return;

                _cstatus = value;

                HandlePropertyChanged();
            }
        }

        void HandlePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
