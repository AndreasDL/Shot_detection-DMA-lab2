using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShotDetector {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ShotDetector());

            //ShotCollection groundTruth = new ShotCollection("C:\\testfiles_dma\\return_jedi_trailer_cuts-only_GT.xml");
            String file = "C:\\testfiles_dma\\return_jedi_trailer_cuts-only.avi";

            System.IO.StreamWriter outputMotion = new System.IO.StreamWriter("c:\\testfiles_dma\\timingGlobal.txt");
            for (int distance = 25; distance <= 250; distance += 25) {


                ShotCollection temp = new ShotCollection(0);
                aShotDetectionMethod method = new GlobalHistogramMethod(0.25, distance, temp);

                //Exec method
                DxScan scanner = new DxScan(file, method);
                var sw = Stopwatch.StartNew();
                scanner.Start();
                scanner.WaitUntilDone();
                sw.Stop();
                double time = sw.ElapsedMilliseconds;
                time /= scanner.getFrameCount();

                Console.WriteLine(distance + " - " + time + " s/frame");
                outputMotion.WriteLine(distance + " - " + time + " s/frame");
            }
            outputMotion.Close();

            outputMotion = new System.IO.StreamWriter("c:\\testfiles_dma\\timingLocal.txt");
            for (int distance = 2; distance <= 9; distance++) {
                int bins = distance * distance;

                ShotCollection temp = new ShotCollection(0);
                aShotDetectionMethod method = new LocalHistogram(0.25, 9, bins, temp);

                //Exec method
                DxScan scanner = new DxScan(file, method);
                var sw = Stopwatch.StartNew();
                scanner.Start();
                scanner.WaitUntilDone();
                sw.Stop();
                double time = sw.ElapsedMilliseconds;
                time /= scanner.getFrameCount();

                Console.WriteLine(bins + " - " + time + " s/frame");
                outputMotion.WriteLine(bins + " - " + time + " s/frame");
            }
            outputMotion.Close();

            outputMotion = new System.IO.StreamWriter("c:\\testfiles_dma\\timingTwin.txt");
            for (int distance = 2; distance <= 9; distance++) {
                int bins = distance * distance;

                ShotCollection temp = new ShotCollection(0);
                TwinComparison method = new TwinComparison(31, bins, temp, 1.0, 0.0, 2.0, 1.0);

                //Exec method
                DxScan scanner = new DxScan(file, method);
                var sw = Stopwatch.StartNew();
                scanner.Start();
                scanner.WaitUntilDone();
                method.processData();
                sw.Stop();
                double time = sw.ElapsedMilliseconds;
                time /= scanner.getFrameCount();

                Console.WriteLine(bins + " - " + time + " s/frame");
                outputMotion.WriteLine(bins + " - " + time + " s/frame");
            }
            outputMotion.Close();

            outputMotion = new System.IO.StreamWriter("c:\\testfiles_dma\\timingMotion.txt");
            int[] windows = { 9, 11, 15, 19 };
            for (int distance = 2; distance <= 64; distance *= 2) {
                for (int window = 0; window < 4; window++) {
                    ShotCollection temp = new ShotCollection(0);
                    aShotDetectionMethod method = new LogMotionMethod(distance, windows[window], temp, 0.5, 100, 1);

                    //Exec method
                    DxScan scanner = new DxScan(file, method);
                    var sw = Stopwatch.StartNew();
                    scanner.Start();
                    scanner.WaitUntilDone();
                    sw.Stop();
                    double time = sw.ElapsedMilliseconds;
                    time /= scanner.getFrameCount();

                    Console.WriteLine(distance + " - " + windows[window] + " - " + time + " s/frame");
                    outputMotion.WriteLine(distance + " - " + windows[window] + " - " + time + " s/frame");
                }
            }
            outputMotion.Close();


        }
    }
}

