using System;
using System.Collections.Generic;

namespace MemberRegistry.controller 
{
    class ViewMember : IMenuItemCommand
    {
        public string Description {get;}
        public MenuCategory[] Tags {get;}

        private view.Console view;

        public ViewMember(MenuCategory[] tags, string description, view.Console view) {
            this.Tags = tags;
            this.Description = description;
            this.view = view;
        }

        public void ExecuteCommand(model.MemberRegistry registry, Dictionary<string, string> data) {
            int id;
            int.TryParse(data["number"], out id);
            model.Member member = registry.GetMember(id);
            dynamic viewModelMember = new {Name = member.Name, PersonalNumber = member.PersonalNumber, MemberID = member.MemberID};
                view.DisplayUserInfo(viewModelMember);

                 if (member.boats.Count > 0) {
                    view.DisplayInstructions("Boats:");
                    int i = 1;
                    foreach (model.Boat boat in member.boats) {
                    dynamic viewModelBoat = new {Number = i, Length = boat.Length, BoatType = boat.Type.ToString()};
                    i++;

                    view.DisplayUserInfo(viewModelBoat);
                    }
                }
            
        }

        public Dictionary<string, string> GetData(view.Console view) {

            string number = view.GetUserString("What is the id of the member you would like to view?");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("number", number);

            return data;
        }
    }
}