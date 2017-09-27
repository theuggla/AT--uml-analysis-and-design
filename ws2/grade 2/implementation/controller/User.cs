using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace MemberRegistry.controller
{
	class User
	{
		private view.Console m_view;
		
		private model.MemberLedger m_ledger;

		private controller.MenuController m_menuController;

		public User(view.Console a_view, model.MemberLedger a_ledger)
		{
			m_view = a_view;
			m_ledger = a_ledger;
		}

		public void StartProgram()
		{
			m_view.DisplayInstructions("Hi.");

			while (true)
			{
				controller.IMenuItemCommand useCase = this.m_menuController.GetCorrectUseCase();
				PlayOutUseCase(useCase);

			}

		}

		private void PlayOutUseCase(controller.IMenuItemCommand useCase)
		{
			Dictionary<string, string> data = new Dictionary<string, string>();/*useCase.GetData(m_view);*/
			useCase.ExecuteCommand(m_ledger, data);
		}
	}
}