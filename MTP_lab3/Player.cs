using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTP_lab3
{
    class Player
    {
        private string name_;
        private string cnp_;
        private string gamePosition_;

        public Player(string name, string cnp, string gamePosition)
        {
            name_ = name;
            cnp_ = cnp;
            gamePosition_ = gamePosition;
        }

        public string getName
        {
            get { return name_; }
        }

        public string getPlayerGamePosition
        {
            get { return gamePosition_; }
        }

        public string getCnp
        {
            get { return cnp_; }
        }

        public DateTime getBirthDateFromCnp()
        {
            string year = "";
            if (cnp_[0] == '1' || cnp_[0] == '2')
            {
                year = "19";
            }
            else if (cnp_[0] == '4' || cnp_[0] == '5')
            {
                year = "20";
            }
            year += cnp_.Substring(1, 2);
            string month = cnp_.Substring(3, 2);
            string day = cnp_.Substring(5, 2);

            return (Convert.ToDateTime(month + "/" + day + "/" + year));
        }

        public string getAge()
        {
            DateTime birthDate = getBirthDateFromCnp();
            int age = DateTime.Now.Year - birthDate.Year;
            if ((DateTime.Now.Month < birthDate.Month) ||
                 (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
            {
                age--;
            }

            return Convert.ToString(age);
        }
    }
}