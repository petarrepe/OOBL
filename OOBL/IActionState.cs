namespace OOBL
{
    public interface IActionState
    {
        /// <summary>
        /// Svaki Action state mora znati završiti svoju operaciju 
        /// </summary>
        void Exit();

        void PerformOperation();
    }
}
