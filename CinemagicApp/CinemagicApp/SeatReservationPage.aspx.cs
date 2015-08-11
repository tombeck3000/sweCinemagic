using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOcinemagic;

namespace PLWebcinemagic
{
    public partial class SeatReservationPage : System.Web.UI.Page
    {
        private Movie chosenScreening;
        private Order newOrder;
        private User loggedUser;
        private string userId;
        private List<int> seats = new List<int>();
        private List<OrderDetail> orderDetails = new List<OrderDetail>();  
            
        protected void Page_Load(object sender, EventArgs e)
        {
             newOrder = new Order();

            if (!IsPostBack)
            {
               
                chosenScreening = (Movie) Session["chosenScreening"];
                loggedUser = (User) Session["loggedUser"];
                userId = loggedUser.UserId;
                
                lblMovieTitle.Text = chosenScreening.Title;
                lblMovieTime.Text = chosenScreening.Date.Day.ToString().PadLeft(2, '0') + "." + chosenScreening.Date.Month.ToString().PadLeft(2, '0') + "." + chosenScreening.Date.Year + ", " + chosenScreening.Time.Hour.ToString().PadLeft(2, '0') + ":" + chosenScreening.Time.Minute.ToString().PadLeft(2, '0');
                            
                CreateDropDowns();
            }
            
        }

        private void CreateDropDowns()
        {
            ddlRow.Items.Add(new ListItem("1", "1"));
            ddlRow.Items.Add(new ListItem("2", "2"));
            ddlRow.Items.Add(new ListItem("3", "3"));
            ddlRow.Items.Add(new ListItem("4", "4"));
            ddlRow.Items.Add(new ListItem("5", "5"));
            ddlRow.Items.Add(new ListItem("6", "6"));
            ddlRow.Items.Add(new ListItem("7", "7"));
            ddlRow.Items.Add(new ListItem("8", "8"));
            ddlRow.Items.Add(new ListItem("9", "9"));
            ddlRow.Items.Add(new ListItem("10", "10"));

            ddlSeat.Items.Add(new ListItem("1", "1"));
            ddlSeat.Items.Add(new ListItem("2", "2"));
            ddlSeat.Items.Add(new ListItem("3", "3"));
            ddlSeat.Items.Add(new ListItem("4", "4"));
            ddlSeat.Items.Add(new ListItem("5", "5"));
            ddlSeat.Items.Add(new ListItem("6", "6"));
            ddlSeat.Items.Add(new ListItem("7", "7"));
            ddlSeat.Items.Add(new ListItem("8", "8"));
            ddlSeat.Items.Add(new ListItem("9", "9"));
            ddlSeat.Items.Add(new ListItem("10", "10"));
            ddlSeat.Items.Add(new ListItem("11", "11"));
            ddlSeat.Items.Add(new ListItem("12", "12"));
            ddlSeat.Items.Add(new ListItem("13", "13"));
            ddlSeat.Items.Add(new ListItem("14", "14"));
            ddlSeat.Items.Add(new ListItem("15", "15"));
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultPage.aspx");
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookedPage.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int row = Convert.ToInt32(ddlRow.SelectedValue);
            int seat = Convert.ToInt32(ddlSeat.SelectedValue);

            ListItem rowItem = ddlRow.SelectedItem;
            ListItem seatItem = ddlSeat.SelectedItem;

            UpdateChosenSeatLabel(row, seat);
            
            seats.Add(Order.GetSeatId(row, seat));

            AddNewOrderDetail(Order.GetSeatId(row, seat));
            //AddSeatToOrder(ddlRow.SelectedIndex, ddlSeat.SelectedIndex);
            //RefreshDropDowns(rowItem, seatItem);
            //ddlSeat.SelectedIndex = ddlSeat.SelectedIndex + 1;

        }

        private void AddNewOrderDetail(int seatId)
        {
            OrderDetail od = new OrderDetail();
            od.OrderId = newOrder.OrderId;
            od.SeatId = seatId;
            orderDetails.Add(od);
        }

        //private void AddSeatToOrder(int row, int seat)
        //{
        //    newOrder.MovieScreeningId = chosenScreening.MovieScreeningId;
        //    newOrder.UserId = Session["UserId"].ToString();
        //    int seatId = Order.GetSeatId(row, seat);
        //    newOrder.SeatId = seatId;
        //}

        private void RefreshDropDowns(ListItem row, ListItem seat)
        {
            //complicated, because this depends on the selected row
            //if all seats in one row are selected, then the row is full and so on
            //foreach (ListItem item in ddlRow.Items)
            //{
            //    if (item == row)
            //    {
            //        item.Attributes.Add("disabled", "disabled");              
            //    }
            //}
            //foreach (ListItem item in ddlSeat.Items)
            //{
            //    if (item == seat)
            //    {
            //        item.Attributes.Add("disabled", "disabled");
            //    }
            //}
        }

        private void UpdateChosenSeatLabel(int row, int seat)
        {
            if (lblChoosenSeat.Text != "")
            {
                lblChoosenSeat.Text = lblChoosenSeat.Text + "; R" + row + "/S" + seat;    
            }
            else
            {
                lblChoosenSeat.Text = "R" + row + "/S" + seat;
            }
        }

        protected override object SaveViewState()
        {
            // create object array for Item count + 1
            object[] allStates = new object[this.Items.Count + 1];

            // the +1 is to hold the base info
            object baseState = base.SaveViewState();
            allStates[0] = baseState;

            Int32 i = 1;
            // now loop through and save each Style attribute for the List
            foreach (ListItem li in this.Items)
            {
                Int32 j = 0;
                string[][] attributes = new string[li.Attributes.Count][];
                foreach (string attribute in li.Attributes.Keys)
                {
                    attributes[j++] = new string[] { attribute, li.Attributes[attribute] };
                }
                allStates[i++] = attributes;
            }
            return allStates;
        }

        protected override void LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                object[] myState = (object[])savedState;

                // restore base first
                if (myState[0] != null)
                    base.LoadViewState(myState[0]);

                Int32 i = 1;
                foreach (ListItem li in this.Items)
                {
                    // loop through and restore each style attribute
                    foreach (string[] attribute in (string[][])myState[i++])
                    {
                        li.Attributes[attribute[0]] = attribute[1];
                    }
                }
            }
        }
    }

    struct OrderDetail
    {
        private string orderDetailId;
        private string orderId;
        private int seatId;

        public string OrderDetailId
        {
            get { return orderDetailId; }
            set { orderDetailId = Guid.NewGuid().ToString(); }
        }
        public string OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public int SeatId
        {
            get { return seatId; }
            set { seatId = value; }
        }


    }
}