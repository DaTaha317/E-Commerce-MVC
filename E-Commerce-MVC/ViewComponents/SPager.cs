namespace E_Commerce_MVC.ViewComponents
{
	public class SPager
	{
		// Searching Properties
		public string SearchText { get; set; }
		public string Controller { get; set; }
		public string Action { get; set; }

		// Paging Properties
		public int TotalItems { get; private set; }
		public int CurrentPage { get; private set; }
		public int PageSize { get; private set; }
		public int TotalPages { get; private set; }
		public int StartPage { get; private set; }
		public int EndPage { get; private set; }

		public SPager() { }

		// Searching overloading
		public SPager(string Controller, string Action, string SearchText)
        {
            this.Controller = Controller;
            this.Action = Action;
            this.SearchText = SearchText;
        }

        // Paging overloading
        public SPager(int totalItems, int page, int pageSize = 10)
        {
			int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
			int currentPage = page;
			int startPage = currentPage - 5;
			int endPage = currentPage + 4;

			if (startPage <= 0)
			{
				endPage = endPage - (startPage - 1);
				startPage = 1;
			}

			if (endPage > totalPages)
			{
				endPage = totalPages;
				if(endPage > 10)
				{
					startPage = endPage - 9;
				}
			}

			TotalItems = totalItems;
			CurrentPage = currentPage;
			PageSize = pageSize;
			TotalPages = totalPages;
			StartPage = startPage;
			EndPage = endPage;
        }


        
    }
}
