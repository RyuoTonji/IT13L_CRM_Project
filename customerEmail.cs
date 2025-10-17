using MyKioski.Models;

namespace MyKioski
{
    public partial class customerEmail : Form
    {
        private String concernType;
        public customerEmail()
        {
            InitializeComponent();
        }

        // Inquiry button click
        private void inquiryBtn_Click(object sender, EventArgs e)
        {
            ResetButtonColors();                          // reset others
            inquiryBtn.BackColor = Color.LightBlue;       // highlight this
            concernType = "Inquiry";
        }

        // Complaint button click
        private void complaintBtn_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            complaintBtn.BackColor = Color.LightBlue;
            concernType= "Complaint";
        }

        // Others button click
        private void othersBtn_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            othersBtn.BackColor = Color.LightBlue;
            concernType= "Others";
        }

        private void ResetButtonColors()
        {
            inquiryBtn.BackColor = SystemColors.Control;   // default button color
            complaintBtn.BackColor = SystemColors.Control;
            othersBtn.BackColor = SystemColors.Control;
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailBox.Text) ||
                string.IsNullOrWhiteSpace(feedbackBox.Text) ||
                string.IsNullOrEmpty(concernType))
            {
                MessageBox.Show("Please fill in all fields and select a type of concern.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Database.InsertFeedback(emailBox.Text, feedbackBox.Text, concernType);

                MessageBox.Show("Your feedback has been sent! Thank you.",
                                "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset UI
                emailBox.Clear();
                feedbackBox.Clear();
                ResetButtonColors();
                concernType = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
     