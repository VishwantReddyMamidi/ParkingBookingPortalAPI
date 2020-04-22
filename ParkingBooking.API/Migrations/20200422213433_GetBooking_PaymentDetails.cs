using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingBooking.API.Migrations
{
    public partial class GetBooking_PaymentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetBooking_PaymentDetails]
                        as 
                        select BT.[BookingID]
                              ,PT.[PaymentTranscationID]
                              ,PT.[AmountPaid]
	                          ,BT.[FullName]
                              ,BT.[Email]
                              ,BT.[Phone]
                              ,BT.[CarPlate#]
                              ,BT.[BookedDates]
                              ,BT.[NumberofDaysBooked]
                              ,BT.[BookedOn]
	                          from [ParkingBookingPortal].[dbo].[BookingsTable] BT
	                          INNER JOIN 
	                          [ParkingBookingPortal].[dbo].[PaymentTranscationTable] PT
                              on
	                          BT.BookingID = PT.BookingID";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

        }
    }
}
