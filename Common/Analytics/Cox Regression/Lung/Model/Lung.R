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

# Load below packages
library(pmml)
library(survival)

# Here we directly load the cancer dataset installed with the "survival" package.
data(cancer)

# rename column names for lung dataset from survival package
lungOriginal <- setNames(cancer, c("Code", "Survival_Time", "Censoring_Status", "Age", "Sex", "ECOG_Score", "Physician_Score", "Patient_Score",
"Calories_Consumed", "Weight_Loss"))

# Omit rows with missing values
lungOriginal = na.omit(lungOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from package.
# setwd("C:/actual_data_location")
# lung = read.csv("Lung.csv")

# Divide dataset for training and test
trainData=lungOriginal[1:133,]
testData=lungOriginal[134:167,]

# Applying Cox Regression Model to predict Survival
lung_Cox = coxph(Surv(Survival_Time,Censoring_Status)~Code+Age+Sex+ECOG_Score+Physician_Score+Weight_Loss, trainData)
summary(lung_Cox)

# Calculate Survival fit of the model
survfit(lung_Cox, trainData)
plot(survfit(lung_Cox))  

# Display the predicted results
# Predict "Survival" column for test data set
lungTestPrediction = predict(lung_Cox, type = "expected",testData)
# Display predicted values
lungTestPrediction 


# The code below is used for evaluation purpose. 
# The model is applied for original lung data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Cox Regression model to entire dataset and save the results in a CSV file
lungEntirePrediction = predict(lung_Cox, type = "expected", lungOriginal)

# PMML generation
pmmlFile<-pmml(lung_Cox, data=lungOriginal)
write(toString(pmmlFile), file="Lung.pmml")
saveXML(pmmlFile, file="Lung.pmml")

# Save predicted value in a data frame
result = data.frame(lungEntirePrediction)
names(result) = c("Predicted_Survival")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)

