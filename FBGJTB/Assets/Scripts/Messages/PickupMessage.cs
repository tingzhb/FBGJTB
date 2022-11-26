
using System.Numerics;

public class PickupMessage : IMessage {
	public int PickUpNumber { get; set; }
	public bool IsRightPlayer{ get; set; }
}
