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
# install.packages("kernlab")
# install.packages("pmml") 
# install.packages("gmodels") 
# install.packages("reshape2") 

# Load below packages
library(kernlab)
library(pmml)
library(reshape2) # This package is specifically loaded for tips dataset shipped within it.
library(gmodels)

# Here we directly loaded the tips dataset installed with the "reshape2" package.
data(tips)

# rename column names in tips dataset from reshape2 package
tipsOriginal <- setNames(tips, c("Total_Bill", "Tip_Amount", "Sex", "Smoker", "Day", "Time", "Size"))

# Omit rows with missing values
tipsOriginal <- na.omit(tipsOriginal) 

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# tips<- read.csv("tips.csv")

# Randomizing data
tips<- tipsOriginal[sample(nrow(tipsOriginal)),]

# Divide dataset for training and test
trainData<-tips[1:195,]
testData<-tips[196:244,]

# Applying Support vector Machine Function using Linear kernel- "vanilladot"
tips_SVM<-ksvm(Tip_Amount~.,data=trainData,kernel="vanilladot")
tips_SVM

# Predict "Tip" column for test data set
tipsTestPrediction<-predict(tips_SVM,testData)
# Display predicted values
tipsTestPrediction

# PMML generation
pmmlFile<-pmml(tips_SVM,data=trainData)
write(toString(pmmlFile),file="Tips.pmml")
saveXML(pmmlFile,file="Tips.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original Tips data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Support vector Machine model to entire dataset and save the results in a CSV file
tipsEntirePrediction<-predict(tips_SVM,tipsOriginal)
tipsEntirePrediction

# Save predicted value in a data frame
result = data.frame(tipsEntirePrediction)
names(result) = c("Predicted_TipAmount")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)