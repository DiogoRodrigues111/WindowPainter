using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace WindowsPainter
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Abre a janela de cores
        /// </summary>
        private ColorDialog mColorDialog = new ColorDialog();
        /// <summary>
        /// Add cor p/ um componente
        /// </summary>
        private Color mColor = new Color();
        /// <summary>
        /// Define para retornar com a função 'IsPaintComponent'
        /// </summary>
        private Color mResultColor = new Color();
        /// <summary>
        /// Obtém o Pincél p/ pintar
        /// </summary>
        private SolidBrush mBrushSolid { set; get; }
        /// <summary>
        /// Variavel p/ Grafico 2D
        /// </summary>
        private Graphics mGraphics { set; get; }
        /// <summary>
        /// Se o componente é pintavel
        /// </summary>
        private bool IsPaintComponent = false;

        private bool IsMover = false;

        public Form1()
        {
            InitializeComponent();
            // Inicializa um controle criado por painel1
            mGraphics = ((Control)this.panel1).CreateGraphics();
            // Chama a função do painel que é clicado
            ((Control)this.panel2).Click += new EventHandler(ColorSelectDialog);
            // Chama a função do desenho
            // Mouse Click
            ((Control)this.panel1).MouseClick += new System.Windows.Forms.MouseEventHandler(ComponentMouseClick);
            // MouseDown
            ((Control)this.panel1).MouseDown += new System.Windows.Forms.MouseEventHandler(ComponentMouseDown);
            // Mouse Up
            ((Control)this.panel1).MouseUp += new System.Windows.Forms.MouseEventHandler(ComponentMouseUp);
            // Mouse Move
            ((Control)this.panel1).MouseMove += new System.Windows.Forms.MouseEventHandler(ComponentMouseMove);
            // MouseHover
            ((Control)this.panel1).MouseHover += new System.EventHandler(ComponentMouseHover);
        }
        /// <summary>
        /// Obtém as color classicas p/ ser add a um componentes
        /// </summary>
        /// <param name="argb">Obtém as color Alpha, Red, Green, e Blue. Em um formato somente</param>
        /// <returns></returns>
        private Color GetMyColor(int alpha, int red, int green, int blue)
        {
            // Retorna 255 cor alternadas entre alpha, red, green, e blue
            return Color.FromArgb(alpha, red, green, blue);
        }
        /// <summary>
        /// Obtém a reação do ColorDialog quando o painel da cor está sobre ativação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorSelectDialog(Object sender, EventArgs e)
        {
            // Variavel atribuida ao dialog show
            DialogResult result = mColorDialog.ShowDialog();
            // Obtém o resultado da cor que o usuário selecionou
            mResultColor = mColor;
            // Instancia um novo objeto, com o parametro de cor que o usuário selecionou
            mBrushSolid = new SolidBrush(mResultColor);
            // mColor recebe a cor atual do SolidBrush
            mColor = mBrushSolid.Color;

            if (result == DialogResult.Cancel)
                return;

            if(result == DialogResult.OK)
            {
                // Armazena os resultados obtidos pelo usuário
                mColor = mColorDialog.Color;
                // Chama a rotina caso o paint está ativo
                // Caso contrário retorna falso
                //IsPaintComponent(mResultColor);
                // Desenha as linhas no formulario 'painel1'
                //AddLinesForForm(trackBar1.Value);
            }
        }
        /// <summary>
        /// Obtém a relação do mouse quando é clicado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentMouseDown(Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Quando o mouse é clicado altera p/ true o resultado
            IsPaintComponent = true;
        }
        /// <summary>
        /// Obtém a relação do mouse quando ele é solto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentMouseUp(Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Quando o botão do mouse é soltado, a variavel é falsa
            IsPaintComponent = false;
        }
        /// <summary>
        /// Obtém a relação do mouse quando ele se move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentMouseMove(Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (IsPaintComponent == true)
            {
                // mColor recebe o valor que o usuário selecionou no dialog
                mColor = mColorDialog.Color;
                // Instancia um novo objeto, e manda como cor padrão o mColor selecionado pelo usuário
                mBrushSolid = new SolidBrush(mColor);

                // Desenha o pincél     //                              DESENHO                               //
                mGraphics.FillEllipse(  // ---------------------------------------------------------------------
                    mBrushSolid,        // Brush or BrushSolid
                    e.X,                // Event X, busca as coordenadas do mouse X
                    e.Y,                // Event Y, busca as coordenadas do mouse Y
                    trackBar1.Value,    // Width Value, obtém o value selecionado pelo usuário de altura
                    trackBar1.Value);   // Height Value, obtém o value selecionado pelo usuário de largura
            }
        }
        /// <summary>
        /// Event Mouse Hover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentMouseHover(Object sender, EventArgs e)
        {
            /* Sem Implementação */
        }
        /// <summary>
        /// Event Mouse Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentMouseClick(Object sender, EventArgs e)
        {
            /* Sem Implementação */
        }

        bool HaveMove()
        {
            if (IsMover == false)
                IsMover = true;

            return IsMover = true;
        }

        private void TrackMouseMove(Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (Mouse.LeftButton < MouseButtonState.Pressed)
            {
                trackBar1.Location = e.Location;
            }
        }

        private void OnTrackMove(Object sender, EventArgs e)
        {

        }

        private void OnTrackLocationChanged(object sender, EventArgs e)
        {
            var save = trackBar1.Location;
        }
    }
}
