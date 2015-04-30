using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;

using System.IO;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace MultiFaceRec
{
    public partial class onefacedetection : Form
    {
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
        int ContTrain, NumLabels, t,counter=0;
        string name, names = null;
        string flder;
        int pro = 0;
        public onefacedetection()


        {
            InitializeComponent();
            face = new HaarCascade("haarcascade_frontalface_alt2.xml");
        }

        private void browsevideo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
             if (currentFrame != null)
            {
                Application.Idle -= FrameGrabber;
            }
        }

        private void btn_decrec_Click(object sender, EventArgs e)
        {
            //bitmapsource bpsou = new bitmapsource();
            try
            {
                currentFrame = grabber.QueryFrame();
                if (currentFrame != null || flder == "" )
                {
                    //Initialize the FrameGraber event

                    Application.Idle += new EventHandler(FrameGrabber);
                    btn_decrec.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Browse the Video First", "No videos Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label16.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Browse the Video First", "No videos Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label16.Text = "";
            }
        }
        

        private void onefacedetection_Load(object sender, EventArgs e)
        {
            // can leave this empty
        }

        private void btnfolder_Click(object sender, EventArgs e)
        {
           
        }

        void FrameGrabber(object sender, EventArgs e)
        {
            currentFrame = grabber.QueryFrame();
            if (currentFrame != null)
            {
                if (counter >= 1)
                {
                    label5.Text = "Selected character found in frame";
                    labcounter.Text = ":"+counter+"times.";
                }

                //label3.Text = "0";
                //label4.Text = "";
                //NamePersons.Add("");
                try
                {
                    //Get the current frame form capture device
                    currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                }
                catch (Exception ex)
                {
                    Application.Idle += new EventHandler(checkoutput);
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
                pro = 0;

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);

                    imageBox2.Image = result;
                    if (FaceImgaes.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbers of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer

                        Emgu.CV.EigenObjectRecognizer recognizer = new Emgu.CV.EigenObjectRecognizer(
                           FaceImgaes.ToArray(),
                           labels.ToArray(),
                           2000,
                           ref termCrit);

                        name = recognizer.Recognize(result);
                        if (pro == 0)
                        {
                            if (name != "")
                            {
                                counter++;
                                currentFrame.Draw(f.rect, new Bgr(Color.Green), 2);
                                pro++;

                            }



                            //Draw the label for each face detected and recognized
                            currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                        }
                    }
                    else
                    {
                        imageBox2.Image = currentFrame;
                    }


                   


                    //Set the number of faces detected on the scene
                    label4.Text = facesDetected[0].Length.ToString();
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
                

                
                //Show the faces procesed and recognized
                imageBoxFrameGrabber.Image = currentFrame;
                names = "";
                //Clear the list(vector) of names
                NamePersons.Clear();


            }
            else
            {
                btn_decrec.Enabled = true;
                label16.Text = "";
            }
        }

        void checkoutput(object sender, EventArgs e)
        { 
            if(counter!=0){
                labresult.Text =  "Face selected was detected and recognised. Selected appeared in"+counter+"frames";
                return;
            }else{
                labresult.Text = "Sorry!! The face Detected did not appear in the Video";
                return;
            }
        }

        private void browsevideo_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Idle -= new EventHandler(FrameGrabber);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Initialize the capture device
                grabber = new Capture(openFileDialog1.FileName);
                label16.Text = openFileDialog1.SafeFileName;
                grabber.QueryFrame();
                Application.Idle -= new EventHandler(FrameGrabber);
            }
        }

        private void btnfolder_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Idle -= new EventHandler(FrameGrabber);
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                //Initialize the capture device
                flder = folderBrowserDialog1.SelectedPath;
                label26.Text = flder;
                Application.Idle -= new EventHandler(FrameGrabber);

                try
                {
                    //Load of previus trainned faces and labels for each image
                    string Labelsinfo = File.ReadAllText(flder + "/Names.txt");
                    string[] Labels = Labelsinfo.Split('%');
                    NumLabels = Convert.ToInt16(Labels[0]);
                    ContTrain = NumLabels;
                    string LoadFaces;

                    for (int tf = 1; tf < NumLabels + 1; tf++)
                    {
                        LoadFaces = "face" + tf + ".bmp";
                        FaceImgaes.Add(new Image<Gray, byte>(flder + "/" + LoadFaces));
                        labels.Add(Labels[tf]);
                    }

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(e.ToString());
                    MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void onefacedetection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            intermediate intermediate = new intermediate();
            intermediate.Show();
            this.Hide();
        }

 
       
    }
}
