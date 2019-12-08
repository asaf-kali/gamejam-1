@echo off

set BRANCHES=asaf bar eyal noga oren

for %%b in (%BRANCHES%) do ( 
   git checkout %%b
   git pull
   git rebase master
   git push
)
echo Done
