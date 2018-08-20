using LibraryWebsiteData;
using LibraryWebsiteData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        private LibraryContext _context;
        public LibraryAssetService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
                return _context.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location);
        }

    

        public LibraryAsset GetByID(int id)
        {
            return
                GetAll()
                .FirstOrDefault(asset => asset.ID == id);
        }

        public LibraryBranch getCurrentLocation(int id)
        {
            return GetByID(id).Location;
        }

        public string getDeweyIndex(int id)
        {
            if (_context.Books.Any(book => book.ID == id))
            {
                return _context.Books.FirstOrDefault(book => book.ID == id).DeweyIndex;
            }
            else return "";
        }

        public string getIsbn(int id)
        {
            if (_context.Books.Any(book => book.ID == id))
            {
                return _context.Books.FirstOrDefault(book => book.ID == id).ISBN;
            }
            else return "";
        }
        public string getTitle(int id)
        {
            return _context.LibraryAssets
                .FirstOrDefault(a => a.ID == id)
                .Title;
        }

        public string getType(int id)
        {
            var book = _context.LibraryAssets.OfType<Book>()
                .Where(b => b.ID == id);
            return book.Any() ? "Book" : "Video";
        }
        public string getAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>()
                .Where(asset => asset.ID == id).Any();
            var isVidoe = _context.LibraryAssets.OfType<Video>()
                .Where(asset => asset.ID == id).Any();

            return isBook ?
                _context.Books.FirstOrDefault(book => book.ID == id).Author :
                _context.Videos.FirstOrDefault(video => video.ID == id).Director
                ?? "Unknown";


        }
    }
}
