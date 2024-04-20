using LibraryManagment.Models;
using LibraryManagment.Services;
using Microsoft.AspNetCore.Components;

namespace LibraryManagment.Components.Pages
{
    public partial class Members : PagesInterface
    {
        // Initialize variables
        public List<Member> members = new List<Member>();

        private Member member = new Member();
        private Member currentMember = new Member();

        private MemberAcessor memberAcessor = new MemberAcessor();

        bool invalidPhone = false;
        bool invalidEmail = false;

        //Get list of DB items into a list
        protected override void OnInitialized()
        {
            members = memberAcessor.Get();
        }

        //Add new book
        public void Add()
        {
            if (members.Any(e => e.Phone == member.Phone))
            {
                invalidPhone = true;
                return;
            }
            if (members.Any(e => e.Email == member.Email))
            {
                invalidEmail = true;
                return;
            }

            memberAcessor.Add(member);

            members = memberAcessor.Get();

            member = new Member { };

            invalidPhone = false;
            invalidEmail = false;
        }
        //Remove new book
        public void Remove(Member member)
        {
            memberAcessor.Remove(member);

            members = memberAcessor.Get();
        }
        //Select currentBook by id and display contents
        public void Select(ChangeEventArgs e)
        {
            int selectedId = int.Parse(e.Value.ToString());

            if (selectedId > 0)
            {
                currentMember = members.FirstOrDefault(member => member.MemberId == selectedId);
            }
            return;
        }
    }
}
