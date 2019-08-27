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
# install.packages("pmml")
# install.packages("survival")
# install.packages("KMsurv")

# Load below packages
library(pmml)
library(survival)
library(KMsurv) #This package is specifically loaded for bfeed data shipped within it. 

# Here we directly load the larynx dataset installed with the "KMsurv" package.
data(bfeed)

# rename column names for bfeed dataset from KMsurv package 
bfeedOriginal <- setNames(bfeed, c("Duration", "Bfeed_Indicator", "Race", "Is_Poor", "Smoker", "Alcoholic", "Age", "Year", "Education_Level", "Prenatal_Care"))

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from package.
# setwd("C:/actual_data_location")
# bfeed = read.csv("Bfeed.csv")

# Divide dataset for training and test
trainData=bfeedOriginal[1:741,]
testData=bfeedOriginal[742:927,]

# Applying Cox Regression Model to predict Survival
bfeed_Cox = coxph(Surv(Duration,Bfeed_Indicator)~Race+Is_Poor+Smoker+Alcoholic+Age+Year+Education_Level+Prenatal_Care, trainData)
summary(bfeed_Cox)

# Calculate Survival fit of the model
survfit(bfeed_Cox, trainData)
plot(survfit(bfeed_Cox))  

# Display the predicted results
# Predict "Survival" column for test data set
bfeedTestPrediction = predict(bfeed_Cox, type = "expected",testData)
# Display predicted values
bfeedTestPrediction 

# The code below is used for evaluation purpose. 
# The model is applied for original bfeed data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Cox Regression model to entire dataset and save the results in a CSV file
bfeedEntirePrediction = predict(bfeed_Cox, type = "expected", bfeedOriginal)

# PMML generation
pmmlFile<-pmml(bfeed_Cox, data=bfeedOriginal)
write(toString(pmmlFile), file="Bfeed.pmml")
saveXML(pmmlFile, file="Bfeed.pmml")

# Save predicted value in a data frame
result = data.frame(bfeedEntirePrediction)
names(result) = c("Predicted_Survival")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)

