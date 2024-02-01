namespace Utility;
 
/// <summary>
/// An enumeration that represents different states in the parsing process.
/// </summary>
 public enum State
 {
     StartLine,
     ElementLine,
     InsideLine,
     InsideList,
     ElementList,
     StartList,
     ElementInsideQuotes,
 }