using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project_Tracker.Core;
using Project_Tracker.MVM.Model;
using Project_Tracker.MVM.ViewModel;

namespace Project_Tracker.MVM.View
{
    /// <summary>
    /// Interaktionslogik für ProgressView.xaml
    /// </summary>
    public partial class ProgressView : UserControl
    {
        public List<StackPanel> sectionStackpanels = new List<StackPanel>();
        public List<CardModel> cards = new List<CardModel>();

        public ProgressView()
        {
            InitializeComponent();
            Setup();
        }

        public void SaveProject()
        {
            // <Save Sections>
            //List<string> temp = new List<string>();

            //foreach (StackPanel panel in sectionStackpanels)
            //{
            //    temp.Add(panel.Name.Replace("section_", ""));
            //}
            //AppManager.openProject.SectionNames = temp.ToArray();


            //// <Save Cards>
            //AppManager.openProject.Cards = cards.ToArray();
            AppManager.SaveProject();

            Reload();
        }

        public void Reload()
        {
            ProjectViewModel.instance.ProgressViewCommand.Execute(null);
        }

        public void Setup()
        {
            LoadSections(); // Read sections names in project file and load them into the project view.
            LoadCards(); // Read cards parent names in project file and load them into the section.

            AddNewCardButton(); // Create a "new Card" button and add it to the end of the section.

                // Add "Add Section" butten at the end of the sections.
                Button btt = new Button() { Style = FindResource("NewSectionButton") as Style };
            Sections.Children.Add(btt);
        }

        private void LoadSections() // Create Sections
        {
            if (AppManager.openProject.Sections is null) return;

            foreach (SectionModel section in AppManager.openProject.Sections)
            {
                // == Load-in Sections from project files. ==
                Border temp = new Border();
                StackPanel tempPanel = new StackPanel() { Name = "section_" + section.Name };

                // Setup Section theme //
                temp.CornerRadius = new CornerRadius(10);
                temp.Background = new SolidColorBrush(Colors.White);
                temp.VerticalAlignment = VerticalAlignment.Top;
                temp.Height = 570;
                temp.Width = 150;
                temp.Margin = new Thickness(5, 0, 5, 0);
                temp.Child = tempPanel;

                // Add Section Title
                tempPanel.Children.Add(new TextBlock() { Text = section.Name, Margin = new Thickness(10), FontWeight = FontWeights.Bold, FontSize = 14 });
                // Add Section name seperator
                tempPanel.Children.Add(new Border() { CornerRadius = new CornerRadius(10), Height = 2, Width = 140, Margin = new Thickness(5, 0, 5, 0), Background = new SolidColorBrush(Colors.LightGray) });

                // view the section
                Sections.Children.Add(temp);
                // add reference to sectionStackPanels
                sectionStackpanels.Add(tempPanel);
            }
        }

        private void LoadCards() // Create cards
        {
            for (int i = 0; i < AppManager.openProject.Sections.Length; i++)
            {
                foreach (StackPanel sectionPanel in sectionStackpanels)
                {
                    if (sectionPanel.Name != "section_" + AppManager.openProject.Sections[i].Name) continue;

                    // <Card Creation>

                    for (int j = 0; j < AppManager.openProject.Sections[i].Cards.Count; j++)
                    {
                        var card = AppManager.openProject.Sections[i].Cards[j];

                        CardInfoButton CardButton = new CardInfoButton()
                        {
                            Content = card.title,
                            FontWeight = FontWeights.SemiBold,
                            FontSize = 12,
                            VerticalAlignment = VerticalAlignment.Top,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            Height = 50,
                            Width = 140,
                            Margin = new Thickness(5, 5, 5, 0),
                            Style = this.FindResource("CardButton") as Style,
                            sectionID = i,
                            CardID = j,
                        };

                        CardButton.Click += (object sender, RoutedEventArgs e) =>
                        {
                            var button = (CardInfoButton)sender;
                            AppManager.openSection = button.sectionID;
                            AppManager.openCard = button.CardID;
                            ProjectViewModel.instance.CurrentView = new CardEditView();
                        };

                        sectionPanel.Children.Add(CardButton); // add card to the section
                        cards.Add(card);
                    }

                    // <Card Creation/>

                }
            }
        }

        private void AddNewCardButton() // Create "new card" button
        {
            foreach (StackPanel sectionPanel in sectionStackpanels)
            {
                for (int i = 0; i < AppManager.openProject.Sections.Length; i++)
                {
                    if (sectionPanel.Name != "section_" + AppManager.openProject.Sections[i].Name) continue;

                    // <AddCardButton>

                    var AddCardButton = new AddCardInfoButton()
                    {
                        Content = "Add new Card",
                        FontSize = 12,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Height = 20,
                        Width = 120,
                        Margin = new Thickness(5, 5, 5, 0),
                        SectionID = i,
                    };
                    AddCardButton.Click += AddNewCard;

                    sectionPanel.Children.Add(AddCardButton);

                    // <AddCardButton/>
                }
            }
        }

        // creates a new button and reloads the project view.
        private void AddNewCard(object sender, RoutedEventArgs e)
        {
            var AddCardButton = sender as AddCardInfoButton;

            CardModel card = new CardModel()
            {
                title = "New Card",
                SectionID = AddCardButton.SectionID,
            };

            cards.Add(card);
            AppManager.openProject.Sections[card.SectionID].Cards.Add(card);
            SaveProject();
        }

    }
}
