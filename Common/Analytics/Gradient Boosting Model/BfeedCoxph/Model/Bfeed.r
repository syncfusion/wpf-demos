# Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
# Use of this code is subject to the terms of our license.
# A copy of the current license can be obtained at any time by e-mailing
# licensing@syncfusion.com. Any infringement will be prosecuted under
# applicable laws. 


# If you are not familiar with R you can obtain a quick introduction by downloading
# R Succinctly for free from Syncfusion - http://www.syncfusion.com/resources/techportal/ebooks/rsuccinctly
# R Succinctly is also included with this installation and is available here
# Installed Drive :\Program Files (x86)\Syncfusion\Essential Studio\XX.X.X.XX\Infrastructure\EBooks\R_Succintly.pdf OF R Succinctly
# Uncomment below lines to install necessary packages if not installed already
#install.packages("gbm")
#install.packages("devtools")
#install.packages("rJava")
#install.packages("githubinstall")
#install.packages("KMsurv")
#install.packages("survival")
#Use 'r2pmml' package version v0.3.0 or below since, the function 'coxph' has been deprecated in later versions. 
#library(githubinstall)
#gh_install_packages("jpmml/r2pmml", ref="0.3.0")

# Load below packages
library(devtools)
library(gbm)
library(rJava)
library(r2pmml)
library(KMsurv) #This package is specifically loaded for bfeed data shipped within it. 
library(survival)

# Here we directly load the bfeed dataset installed with the "KMsurv" package.
data(bfeed)

# rename column names for bfeed dataset from KMsurv package 
bfeedOriginal <- setNames(bfeed, c("Duration", "Bfeed_Indicator", "Race", "Is_Poor", "Smoker", "Alcoholic", "Age", "Year", "Education_Level", "Prenatal_Care"))

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# bfeed= read.csv("bfeed.csv")

# Divide dataset for training and test
trainData=bfeedOriginal[1:741,]
testData=bfeedOriginal[742:927,]

# Applying Genenalized Boosting Model - coxph distribution to predict Survival
bfeed_GBM = gbm(Surv(Duration,Bfeed_Indicator)~Race+Is_Poor+Smoker+Alcoholic+Age+Year+Education_Level+Prenatal_Care, 
        data=trainData, distribution="coxph",cv.folds=5,verbose=FALSE)

# Display the predicted results and create cross table to check on accuracy
# Predict "Survival" column probability for test data set
bfeedTestProbabilities = predict.gbm(bfeed_GBM, newdata=testData, n.trees=100,type="response")
# Display predicted probabilities
bfeedTestProbabilities

# PMML generated will be of version v4.2 since, older version(v0.3.0) 'r2pmml' has been loaded. 
r2pmml(bfeed_GBM ,"Bfeed.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original bfeed data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying GBM model to entire dataset and save the results in a CSV file
bfeedEntirePrediction = predict.gbm(bfeed_GBM, type = "response",bfeedOriginal)

# Save predicted value in a data frame
result = data.frame(bfeedEntirePrediction)
names(result) = c("Predicted_Survival")

# Write the results in a CSV file
write.csv(result, "ROutput.csv" , quote=F)


