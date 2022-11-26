
using System.Numerics;

public class UIChangeMessage : IMessage {
	public int Kills { get; set; }
	public int Deaths { get; set; }
	public int Player { get; set; }
}
