using System;

namespace CarWPF
{
    /// <summary>
    /// Contains fields for representing elements of a road on the canvas.
    /// </summary>
    public class RoadElement
    {
        /// <summary>
        /// Identifier in database. 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Page (aka context) on the canvas. 
        /// </summary>
        public int Page { get; set; }
        
        /// <summary>
        /// Name of the road element (border, center line etc).
        /// </summary>
        /// <remarks>
        /// If a car intersects a center line, it's okay. 
        /// But if a car intersects a border, then a car violated traffic laws. 
        /// </remarks>
        public string Name { get; set; }
        
        /// <summary>
        /// X1 point of a line that represents a road element. 
        /// </summary>
        public int X1 { get; set; }
        
        /// <summary>
        /// Width of a rectangle representing a road element. 
        /// </summary>
        public int X2 { get; set; }
        
        /// <summary>
        /// Left position of a road element. 
        /// </summary>
        public int Y1 { get; set; }   
        
        /// <summary>
        /// Top position of a road element. 
        /// </summary>
        public int Y2 { get; set; } 
    }
}