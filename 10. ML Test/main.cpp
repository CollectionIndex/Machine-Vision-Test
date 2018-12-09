
#include "opencv2/text.hpp"
#include "opencv2/core/utility.hpp"
#include "opencv2/highgui.hpp"
#include "opencv2/imgproc.hpp"
#include "opencv2/ml.hpp"


#include <iostream>

#pragma comment( lib, "opencv_imgproc400d.lib" )
#pragma comment( lib, "opencv_highgui400d.lib" )
#pragma comment( lib, "opencv_core400d.lib" )
#pragma comment( lib, "opencv_text400d.lib" )
#pragma comment( lib, "opencv_imgcodecs400d.lib" )
#pragma comment( lib, "opencv_ml400d.lib" )

using namespace std;
using namespace cv;
using namespace cv::text;
using namespace cv::ml;

void main() {

	int labels[ 4 ] = { 1, 2, 3, 4 };
	float datas[ 4 ] = { 100, 200, 300, 400 };

	Mat trainigData(1, 4, CV_32FC1, datas );
	Mat classes( 1, 4, CV_32SC1, labels );


	Mat layres( 1, 3, CV_32SC1 );
	layres.at< int >( 0 ) = 4;
	layres.at< int >( 1 ) = 3;
	layres.at< int >( 2 ) = 4;
	Ptr< ANN_MLP > ann = ANN_MLP::create();
	load
	ann->setLayerSizes( layres );
	ann->setActivationFunction( ANN_MLP::SIGMOID_SYM, 1, 1 );

	Mat responses( 1, 4, CV_32FC1 );
	ann->train( trainigData, ROW_SAMPLE, responses );


	float sample_data = { 100 };
	Mat sample
	ann->predict()
}