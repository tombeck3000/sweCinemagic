using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOcinemagic
{
    public class Seat
    {
        private int seatId;
        private string category;
        private SqlMoney price;
        private int positionRow;
        private int positionNumber;

        public int SeatId
        {
            get { return seatId; }
            set { seatId = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public SqlMoney Price
        {
            get { return price; }
            set { price = value; }
        }
        public int PositionRow
        {
            get { return positionRow; }
            set { positionRow = value; }
        }
        public int PositionNumber
        {
            get { return positionNumber; }
            set { positionNumber = value; }
        }        
    }
}
