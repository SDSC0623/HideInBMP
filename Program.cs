namespace HideInBMP {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        private static ApplicationContext curContext = new(new MainForm());

        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(curContext);
        }

        public static void Restart() {
            Form oldForm = curContext.MainForm!;
            curContext.MainForm = new MainForm();
            oldForm.Close();
            curContext.MainForm.Show();
        }
    }
}