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
        private static int orderId;
        private static string _userId;
        private static int _movieScreeningId;
        private int seatId;
        private static SqlMoney totalPrice;
        
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public int MovieScreeningId
        {
            get { return _movieScreeningId; }
            set { _movieScreeningId = value; }
        }
        public int SeatId
        {
            get { return seatId; }
            set { seatId = value; }
        }
        public static SqlMoney TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public Order(int movieScreeningId, string userId)
        {
            _movieScreeningId = movieScreeningId;
            _userId = userId;
            //orderId = ;
        }

        public static int FinalizeOrder(List<int[]> seats)
        {
            //GetMainConnection
            SqlConnection con = Main.GetConnection();
            try
            {
                //Convert seat/rows to seatIds
                List<int> seatIds = GetSeatIds(con, seats);
                         
                //Write Order to DB
                string sql = "insert into [Order] (UserID, MovieScreeningID) " +
                                "values (@userId, @movieScreeningId) " +
                                "select OrderID from [Order] order by OrderID desc";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                //cmd.Parameters.Add(new SqlParameter("@orderId", orderId));
                cmd.Parameters.Add(new SqlParameter("@userId", _userId));
                cmd.Parameters.Add(new SqlParameter("@movieScreeningId", _movieScreeningId));
                //cmd.Parameters.Add(new SqlParameter("@totalPrice", totalPrice));

                int newOrderId = Convert.ToInt32(cmd.ExecuteScalar());

                
                //Write OrderDetails to DB and generate totalPrice
                foreach (var seatId in seatIds)
                {
                    SetOrderDetail(con, seatId, newOrderId);
                }


                return newOrderId;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
              
        private static void SetOrderDetail(SqlConnection con, int seatId, int newOrderId)
        {
            string sql = "insert into OrderDetail (OrderID, SeatID) " +
                         "values (@orderId, @seatId)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            //cmd.Parameters.Add(new SqlParameter("@orderDetailId", ));
            cmd.Parameters.Add(new SqlParameter("@orderId", newOrderId));
            cmd.Parameters.Add(new SqlParameter("@seatId", seatId));

            cmd.ExecuteNonQuery();
        }

        public static List<int> GetSeatIds(SqlConnection con, List<int[]> seats)
        {
            List<int> seatIds = new List<int>();
            foreach (int[] rowSeat in seats)
            {
                string sql = "select SeatId from [Seat] " +
                             "where PositionRow = @row and PositionNumber = @seat";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@row", rowSeat[0]));
                cmd.Parameters.Add(new SqlParameter("@seat", rowSeat[1]));

                seatIds.Add(Convert.ToInt32(cmd.ExecuteScalar()));
            }           

            return seatIds;

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
