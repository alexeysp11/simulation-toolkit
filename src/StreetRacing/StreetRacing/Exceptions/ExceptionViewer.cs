namespace StreetRacing.Exceptions
{
    /// <summary>
    /// Class that allows to display exceptions
    /// </summary>
    public static class ExceptionViewer
    {
        /// <summary>
        /// Static method for displaying an exception using MessageBox 
        /// </summary>
        /// <param name="e">Exception that needs to be displayed</param>
        public static void WatchExceptionMessageBox(System.Exception e)
        {
            var st = new System.Diagnostics.StackTrace(e, true);

            //Get the first stack frame
            System.Diagnostics.StackFrame frame = st.GetFrame(0);

            //Get the file name
            string fileName = frame.GetFileName();

            //Get the method name
            string methodName = frame.GetMethod().Name;

            //Get the line number from the stack frame
            int line = frame.GetFileLineNumber();

            //Get the column number
            int col = frame.GetFileColumnNumber();

            System.Windows.MessageBox.Show($@"ERROR: {e.Message}
                File: {fileName} 
                Method: {methodName} ({line}, {col})");
        }
    }
}