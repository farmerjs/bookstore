using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Domain.News
{
    public partial class NewsItem : BaseEntity
    {
        private ICollection<NewsComment> _newsComments;

        public NewsItem()
        {
        }

        /// <summary>
        /// Gets or sets the news title
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Gets or sets the sename
        /// </summary>
        public string SeName { get; set; }

        /// <summary>
        /// Gets or sets the short text
        /// </summary>
        public string Short { get; set; }

        /// <summary>
        /// Gets or sets the full text
        /// </summary>
        public string Full { get; set; }

       

        /// <summary>
        /// Gets or sets the news item start date and time
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the news item end date and time
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }


        /// <summary>
        /// Gets or sets the news comments
        /// </summary>
        public virtual ICollection<NewsComment> NewsComments
        {
            get { return _newsComments ??= new List<NewsComment>(); }
            protected set { _newsComments = value; }
        }

    }
}
