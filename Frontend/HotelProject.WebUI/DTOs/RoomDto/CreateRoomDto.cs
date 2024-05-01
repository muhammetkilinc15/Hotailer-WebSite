﻿namespace HotelProject.WebUI.DTOs.RoomDto
{
	public class CreateRoomDto
	{
		public string RoomNumber { get; set; }
		public string? CoverImage { get; set; }
		public int Price { get; set; }
		public string? Title { get; set; }
		public string? BathCount { get; set; }
		public string? BedCount { get; set; }
		public string? Description { get; set; }
	}
}
