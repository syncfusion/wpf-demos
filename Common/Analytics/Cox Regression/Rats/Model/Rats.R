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

# Here we directly load the rsts dataset installed with the "survival" package.
data(rats)

# rename column names for rats dataset from survival package
ratsOriginal <- setNames(rats, c("Litter_Number", "Treatment", "Survival_Time", "Tumor_Status", "Sex"))

# Omit rows with missing values
ratsOriginal = na.omit(ratsOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from package.
# setwd("C:/actual_data_location")
# rats= read.csv("Rats.csv")

# Divide dataset for training and test
trainData=ratsOriginal[1:250,]
testData=ratsOriginal[251:300,]

# Applying Cox Regression Model to predict Survival
rats_Cox = coxph(Surv(Survival_Time,Tumor_Status)~Litter_Number+Treatment, trainData)
summary(rats_Cox)

# Calculate Survival fit of the model
survfit(rats_Cox, trainData)
plot(survfit(rats_Cox))  

# Display the predicted results
# Predict "Survival" column for test data set
ratsTestPrediction = predict(rats_Cox, type = "expected",testData)
# Display predicted values
ratsTestPrediction 

# PMML generation
pmmlFile<-pmml(rats_Cox, data=trainData)
write(toString(pmmlFile), file="Rats.pmml")
saveXML(pmmlFile, file="Rats.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original rats data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Cox Regression model to entire dataset and save the results in a CSV file
ratsEntirePrediction = predict(rats_Cox, type = "expected", ratsOriginal)

# Save predicted value in a data frame
result = data.frame(ratsEntirePrediction)
names(result) = c("Predicted_Survival")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)

