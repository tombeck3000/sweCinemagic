using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOcinemagic
{
    public class Order
    {
        private string orderId;
        private string userId;
        private int movieScreeningId;
        private int seatId;
        private SqlMoney totalPrice;
        
        public string OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public int MovieScreeningId
        {
            get { return movieScreeningId; }
            set { movieScreeningId = value; }
        }
        public int SeatId
        {
            get { return seatId; }
            set { seatId = value; }
        }
        public SqlMoney TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public Order()
        {
            orderId = Guid.NewGuid().ToString();
        }

        public static int GetSeatId(int row, int seat)
        {
            string sql = "select SeatId from [Seat] " +
                            "where PositionRow = @row and PositionNumber = @seat";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = Main.GetConnection();
            cmd.Parameters.Add(new SqlParameter("@row", row));
            cmd.Parameters.Add(new SqlParameter("@seat", seat));

            return Convert.ToInt32(cmd.ExecuteScalar());
            
        }

        
    }
}
