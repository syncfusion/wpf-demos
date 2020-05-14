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

# Load below packages
library(kernlab)
library(pmml) 
library(gmodels)

# Here we directly load the audit dataset installed with the "pmml" package.
data(audit)

# rename column names in audit dataset from pmml package
auditOriginal <- setNames(audit, c("ID", "Age", "Employment", "Education", "Marital", "Occupation", "Income", "Sex", "Deductions", "Hours", 
"Accounts", "Adjustment", "Adjusted"))

# Omit rows with missing values
auditOriginal <- na.omit(auditOriginal) 

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# audit<- read.csv("Audit.csv")

# Considering integer variable as factor
auditOriginal[, "Adjusted"]=as.factor(auditOriginal[, "Adjusted"])

# Randomizing data
audit<-auditOriginal[sample(nrow(auditOriginal)),]

# Divide dataset for training and test
trainData<-audit[1:1487,]
testData<-audit[1488:1859,]

# Applying Support vector Machine Function using Sigmoid kernel- "tanhdot"
audit_SVM<-ksvm(Adjusted~.,data=trainData,kernel="tanhdot")
audit_SVM

# Display the predicted results and create cross table to check on accuracy
# Predict "Adjusted" column for test data set
auditTestPrediction<-predict(audit_SVM,testData)
# Display predicted values
auditTestPrediction

# Create cross table to check on accuracy.
CrossTable(testData$Adjusted,auditTestPrediction,prop.chisq = FALSE, prop.t = FALSE, prop.r = FALSE,
           dnn = c('actual', 'predicted'))

# PMML generation
pmmlFile<-pmml(audit_SVM,data=trainData)
write(toString(pmmlFile),file="Audit.pmml")
saveXML(pmmlFile,file="Audit.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original Audit data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Support vector Machine model to entire dataset and save the results in a CSV file
auditEntirePrediction<-predict(audit_SVM,audit)
auditEntirePrediction

# Save predicted value in a data frame
result = data.frame(auditEntirePrediction)
names(result) = c("Predicted_Adjusted")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)