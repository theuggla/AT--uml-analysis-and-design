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
		
		private model.MemberRegistry m_registry;

		private controller.MenuController m_menuController;

		public User(view.Console a_view, model.MemberRegistry a_registry)
		{
			m_view = a_view;
			m_registry = a_registry;
			m_menuController = new controller.MenuController(m_registry, m_view);

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
			Dictionary<string, string> data = useCase.GetData(m_view);
			useCase.ExecuteCommand(m_registry, data);
		}
	}
}