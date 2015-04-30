
//Multiple face detection and recognition in real time
//Using EmguCV cross platform .Net wrapper to the Intel OpenCV image processing library for C#.Net
//Writed by Sergio Andrés Guitérrez Rojas
//"Serg3ant" for the delveloper comunity
// Sergiogut1805@hotmail.com
//Regards from Bucaramanga-Colombia ;)

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;
namespace MultiFaceRec
{
    public partial class FrmPrincipal : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Image<Bgr, byte> img;
        
        Capture capture;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, Face = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> FaceImgaes = new List<Image<Gray, byte>>();
        List<string> labels= new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;


        public FrmPrincipal()
        {
            InitializeComponent();
            //Load haarcascades for face detection
            
            face = new HaarCascade("haarcascade_frontalface_alt_tree.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/Faces/Names.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                for (int tf = 1; tf < NumLabels+1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    FaceImgaes.Add(new Image<Gray, byte>(Application.StartupPath + "/Faces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            
            }
            catch(Exception ex)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //bitmapsource bpsou = new bitmapsource();
            try
            {
                currentFrame = grabber.QueryFrame();
                if (currentFrame != null)
                {
                    //Initialize the FrameGraber event

                    Application.Idle += new EventHandler(FrameGrabber);
                    btn_decrec.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Browse the Video First", "No videos Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label6.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Browse the Video First", "No videos Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label6.Text = "";
            }
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
              
             
                //Trained face counter
                ContTrain = ContTrain + 1;
                
                    //Get a gray frame from capture device
                    gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                    //Face Detector
                    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                    face,
                    1.1,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    new Size(20, 20));

                    //Action for each element detected
                    foreach (MCvAvgComp f in facesDetected[0])
                    {
                        Face = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                        break;
                    }

                    //resize face detected image for force to compare the same size with the 
                    //test image with cubic interpolation type method
                    Face = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    FaceImgaes.Add(Face);
                    labels.Add(textBox1.Text);

                    //Show face added in gray scale
                    imageBox1.Image = Face;

                    //Write the number of triained faces in a file text for further load
                    File.WriteAllText(Application.StartupPath + "/Faces/Names.txt", FaceImgaes.ToArray().Length.ToString() + "%");

                    //Write the labels of triained faces in a file text for further load
                    for (int i = 1; i < FaceImgaes.ToArray().Length + 1; i++)
                    {
                        FaceImgaes.ToArray()[i - 1].Save(Application.StartupPath + "/Faces/face" + i + ".bmp");
                        File.AppendAllText(Application.StartupPath + "/Faces/Names.txt", labels.ToArray()[i - 1] + "%");
                    }

                    MessageBox.Show(textBox1.Text + "´s face detected and added :)", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch
            {
                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        void FrameGrabber(object sender, EventArgs e)
        {
            currentFrame = grabber.QueryFrame();
            if (currentFrame != null)
            {
                
                    label3.Text = "0";
                    //label4.Text = "";
                    NamePersons.Add("");
                    try
                    {
                    //Get the current frame form capture device
                    currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Video was Ended", "Frame Query Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //Convert it to Grayscale
                    gray = currentFrame.Convert<Gray, Byte>();

                    //Face Detector
                    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                  face,
                  1.1,
                  10,
                  Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                  new Size(20, 20));

                    //Action for each element detected
                    foreach (MCvAvgComp f in facesDetected[0])
                    {
                        t = t + 1;
                        result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        //draw the face detected in the 0th (gray) channel with blue color
                        currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);

                        imageBox1.Image = result;
                        if (FaceImgaes.ToArray().Length != 0)
                        {
                            //TermCriteria for face recognition with numbers of trained images like maxIteration
                            MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                            //Eigen face recognizer

                            Emgu.CV.EigenObjectRecognizer1 recognizer = new Emgu.CV.EigenObjectRecognizer1(
                               FaceImgaes.ToArray(),
                               labels.ToArray(),
                               3000,
                               ref termCrit);

                            name = recognizer.Recognize(result);

                            //Draw the label for each face detected and recognized
                            currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                        }
                        else
                        {
                            imageBox1.Image = currentFrame;
                        }


                        NamePersons[t - 1] = name;
                        NamePersons.Add("");


                        //Set the number of faces detected on the scene
                        label3.Text = facesDetected[0].Length.ToString();

                        /*
                        //Set the region of interest on the faces
                        
                        gray.ROI = f.rect;
                        MCvAvgComp[][] eyesDetected = gray.DetectHaarCascade(
                           eye,
                           1.1,
                           10,
                           Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                           new Size(20, 20));
                        gray.ROI = Rectangle.Empty;

                        foreach (MCvAvgComp ey in eyesDetected[0])
                        {
                            Rectangle eyeRect = ey.rect;
                            eyeRect.Offset(f.rect.X, f.rect.Y);
                            currentFrame.Draw(eyeRect, new Bgr(Color.Blue), 2);
                        }
                         */

                    }
                    t = 0;

                    //Names concatenation of persons recognized
                    for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                    {
                        names = names + NamePersons[nnn] + ", ";
                    }
                    //Show the faces procesed and recognized
                    imageBoxFrameGrabber.Image = currentFrame;
                    label4.Text = names;
                    names = "";
                    //Clear the list(vector) of names
                    NamePersons.Clear();
                
            }
            else
            {
                btn_decrec.Enabled = true;
                label6.Text = "";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //Process.Start("Donate.html");
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ////Initialize the capture device
            //grabber = new Capture(@"D:\AJ\NationalAnthem.mp4");
            //grabber.QueryFrame();
            ////Initialize the FrameGraber event
            //Application.Idle += new EventHandler(FrameGrabber);
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    capture = new Capture(openFileDialog1.FileName);
            //    img = capture.QueryFrame();
            //    Application.Idle += new EventHandler(img);
            //    Emgu.CV.UI.ImageViewer viewer = new Emgu.CV.UI.ImageViewer();
            //    viewer.Image = img;
            //    viewer.ShowDialog();
            //}
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(FrameGrabber);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Initialize the capture device
                grabber = new Capture(openFileDialog1.FileName);
                label6.Text = openFileDialog1.SafeFileName;
                grabber.QueryFrame();
                Application.Idle -= new EventHandler(FrameGrabber);
            }
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
       
        
    }
}