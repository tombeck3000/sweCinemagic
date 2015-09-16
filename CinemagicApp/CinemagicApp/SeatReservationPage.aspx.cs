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
        private static List<int[]> _seats;
       
            
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                List<int[]> seats = new List<int[]>();
                chosenScreening = (Movie) Session["chosenScreening"];
                loggedUser = (User) Session["loggedUser"];
                userId = loggedUser.UserId;

                newOrder = new Order(chosenScreening.MovieScreeningId, userId);
                _seats = new List<int[]>();
                
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
            int newOrderId = Order.FinalizeOrder(_seats);

            if (newOrderId != -1)
            {
                Response.Redirect("BookedPage.aspx?id=" + newOrderId.ToString() + "");
            }
            else
            {
                lblBookHint.Text = "Please choose Seat and Row";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblAddError.Text = "";

            int row = Convert.ToInt32(ddlRow.SelectedValue);
            int seat = Convert.ToInt32(ddlSeat.SelectedValue);
            
            var combination = new int[] { row, seat };

            bool contains = false;
            foreach (var c in _seats)
            {
                if (c[0] == row && c[1] == seat)
                {
                    contains = true;
                    break;
                }
            }

            if (contains)
            {
                lblAddError.Text = "Seat already added";
            }
            else
            {
                _seats.Add(combination);
                UpdateChosenSeatLabel(row, seat);
            }
                    
        }

        protected void btnDrop_Click(object sender, EventArgs e)
        {
            lblAddError.Text = "";
            lblChoosenSeat.Text = "";
            _seats = new List<int[]>();
        }


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

        protected void ddlRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSeatsDropDown();
        }

        protected void ddlSeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRowsDropDown();
        }

        private void UpdateSeatsDropDown()
        {
            foreach (int[] seat in _seats) {
                if (seat[0] == ddlRow.SelectedIndex)
                {
                    ddlSeat.Items[seat[1]].Attributes.Add("disabled", "disabled");
                }
                
            }
        }

        private void UpdateRowsDropDown()
        {
            foreach (int[] seat in _seats)
            {
                if (seat[1] == ddlSeat.SelectedIndex)
                {
                    ddlRow.Items[seat[0]].Attributes.Add("disabled", "disabled");
                }

            }
        }

       


        //protected override object SaveViewState()
        //{
        //    // create object array for Item count + 1
        //    object[] allStates = new object[this.Items.Count + 1];

        //    // the +1 is to hold the base info
        //    object baseState = base.SaveViewState();
        //    allStates[0] = baseState;

        //    Int32 i = 1;
        //    // now loop through and save each Style attribute for the List
        //    foreach (ListItem li in this.Items)
        //    {
        //        Int32 j = 0;
        //        string[][] attributes = new string[li.Attributes.Count][];
        //        foreach (string attribute in li.Attributes.Keys)
        //        {
        //            attributes[j++] = new string[] { attribute, li.Attributes[attribute] };
        //        }
        //        allStates[i++] = attributes;
        //    }
        //    return allStates;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] myState = (object[])savedState;

        //        // restore base first
        //        if (myState[0] != null)
        //            base.LoadViewState(myState[0]);

        //        Int32 i = 1;
        //        foreach (ListItem li in this.Items)
        //        {
        //            // loop through and restore each style attribute
        //            foreach (string[] attribute in (string[][])myState[i++])
        //            {
        //                li.Attributes[attribute[0]] = attribute[1];
        //            }
        //        }
        //    }
        //}
    }

}