<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerSupport.aspx.cs" Inherits="BPE_Automation.CutomerSupport" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>DGIP - Book an Appointment</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="style.css">
    <style>
        .logo{
            max-width: 80px;
            height: auto;
        }
        form {
    max-width: 600px;
    margin: 0 auto;
    padding: 20px;
    background-color: #f2f2f2;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-family: Arial, sans-serif;
    font-size: 16px;
}

form div {
    margin-bottom: 10px;
}

label {
    display: inline-block;
    width: 150px;
    font-weight: bold;
}

input[type="text"],
select {
    width: 200px;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
    box-sizing: border-box;
}
.sd1{
     width: 200px;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
    box-sizing: border-box;

}
.sd2{
     width: 300px;
   
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
    box-sizing: border-box;

}


 .button {
    background-color: #4CAF50;
    border: none;
    color: white;
    padding: 15px 32px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 16px;
    margin: 4px 2px;
    cursor: pointer;
    border-radius: 5px;
}
 h1 {
  text-align: center;
}
   
    </style>
</head>
<body>
    <!-- Navigation bar -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="#"><img src="Logo.png" alt="DGIP Logo" class="logo"></a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav ml-auto">
                <li class="nav-item">
                    <a class="nav-link" href="Home.aspx">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="BookAppointment.aspx">Book an Appointment</a>
                </li>
                 <li class="nav-item active">
                    <a class="nav-link" href="#">Customer Support</a>
                </li>
            </ul>
        </div>
    </nav>
                <br />
        <br />
        <br />
        <br />
    <h1>Appointment Booking</h1>
    <br />
        <form runat="server">
        <div>
            <label for="name">Name:</label>
            <asp:TextBox ID="name" runat="server" required="true"></asp:TextBox>
        </div>
        <br />
        <div>
            <label for="cnic">CNIC:</label>
<asp:TextBox ID="cnic" runat="server" required="true" pattern="\d{13}" minlength="13" MaxLength="13"></asp:TextBox>
        </div>
        <br />
        <div>
    <label for="email">Email:</label>
    <asp:TextBox class="sd1" ID="email" runat="server" required="true" type="email"></asp:TextBox>
</div>

            <br />
        <div>
            <label>Complain/Query:</label>
            <asp:TextBox class="sd2" ID="txtMessage"  required="true" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button class="button" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    </form>
    <br />
    <br />
    <br />
    <footer class="bg-dark text-white">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <p>&copy; 2023 DGIP. All rights reserved.</p>
            </div>
            <div class="col-md-6 text-right">
                <p>Designed by BPE Automation</p>
            </div>
        </div>
    </div>
</footer>
</body>
</html>