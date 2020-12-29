using Book.Domain.Data;
using Book.Domain.News;
using Book.Service.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Book.Service.News
{
    public partial class NewsService : INewsService
    {
        #region Fields

        private readonly IRepository<NewsItem> _newsItemRepository;
        private readonly IMediator _mediator;

        #endregion

        #region Ctor

        public NewsService(IRepository<NewsItem> newsItemRepository,
            IMediator mediator)
        {
            _newsItemRepository = newsItemRepository;
            _mediator = mediator;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes a news
        /// </summary>
        /// <param name="newsItem">News item</param>
        public virtual async Task DeleteNews(NewsItem newsItem)
        {
            if (newsItem == null)
                throw new ArgumentNullException("newsItem");

            await _newsItemRepository.DeleteAsync(newsItem);

            //event notification
            await _mediator.EntityDeleted(newsItem);
        }

        /// <summary>
        /// Gets a news
        /// </summary>
        /// <param name="newsId">The news identifier</param>
        /// <returns>News</returns>
        public virtual Task<NewsItem> GetNewsById(string newsId)
        {
            return _newsItemRepository.GetByIdAsync(newsId);
        }

        

        /// <summary>
        /// Inserts a news item
        /// </summary>
        /// <param name="news">News item</param>
        public virtual async Task InsertNews(NewsItem news)
        {
            if (news == null)
                throw new ArgumentNullException("news");

            await _newsItemRepository.InsertAsync(news);

            //event notification
            await _mediator.EntityInserted(news);
        }

        /// <summary>
        /// Updates the news item
        /// </summary>
        /// <param name="news">News item</param>
        public virtual async Task UpdateNews(NewsItem news)
        {
            if (news == null)
                throw new ArgumentNullException("news");

            await _newsItemRepository.UpdateAsync(news);

            //event notification
            await _mediator.EntityUpdated(news);
        }

        /// <summary>
        /// Gets all comments
        /// </summary>
        /// <param name="customerId">Customer identifier; "" to load all records</param>
        /// <returns>Comments</returns>
        //public virtual async Task<IList<NewsComment>> GetAllComments(string customerId)
        //{
        //    var query = from n in _newsItemRepository.Table
        //                from c in n.NewsComments
        //                select c;

        //    var query2 = from c in query
        //                 orderby c.CreatedOnUtc
        //                 where (customerId == "" || c.CustomerId == customerId)
        //                 select c;

        //    return await query2.ToListAsync();
        //}

        #endregion
    }
}
